sap.ui.define([
	'./../BaseController',
   	'sap/ui/model/json/JSONModel',
	'./../../repositorio/CarroRepositorio',
	'./../../repositorio/AuxiliaresRepositorio',
	'./../../model/Formatter'
],
	function(BaseController, JSONModel, CarroRepositorio, AuxiliaresRepositorio, Formatter) {
	"use strict";

	const VALOR_INICIAL = null;

	return BaseController.extend("coders.growth.app.carros.Lista", {
		Formatter: Formatter,

		onInit: function() {
			const rota = "lista";
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute(rota).attachPatternMatched(this._aoCoincidirRota, this);
		},

		_modeloFiltro: function(dados){
			const nome = "filtro";
			return this.modelo(nome, dados);
		},

		_modeloAuxiliares: function(dados){
			const nome = "aux";
			return this.modelo(nome, dados);
		},

		_modeloCarros: function(dados){
			const nome = "carros";
			return this.modelo(nome, dados);
		},

		_inicializarModelo: function(){
			this._modeloFiltro(new JSONModel({
				modelo: VALOR_INICIAL,
				proprietarioNome: VALOR_INICIAL,
				anoModelo: VALOR_INICIAL,
				ano: VALOR_INICIAL,
				valorOfertado: VALOR_INICIAL,
				combustivel: VALOR_INICIAL
			}));
		},

		_definirCarros: function(carros){
			const CURRENCY = "BRL";
			carros.forEach(carro => carro.currency = CURRENCY);
			this._modeloCarros(new JSONModel(carros));
		},

		_definirDadosAuxiliares: function(response){
			const PLACE_HOLDER = "Combustível";
			response.unshift(PLACE_HOLDER);
			this._modeloAuxiliares(new JSONModel(response));
		},

		_obterFiltros: function(){
			const INDICE_PLACE_HOLDER = 0;
			const INDICE_INVALIDO = -1;
			const ANO_VALIDO = 4;

			let filtros = this._modeloFiltro().getData();
			if(filtros.ano && filtros.ano.length === ANO_VALIDO){
				filtros.anoModelo = `${filtros.ano}-01-01T00:00:00`
			}
			
			let combustivelSelecionado = this._modeloAuxiliares().getData().findIndex(x => x === filtros.combustivel);

			combustivelSelecionado == INDICE_PLACE_HOLDER || combustivelSelecionado == INDICE_INVALIDO ? 
				filtros.combustivel = VALOR_INICIAL : 
				filtros.combustivel = combustivelSelecionado;

			return filtros;
		},

		_filtrar: function(){
			let filtros = this._obterFiltros();
			return this._obterTodos(filtros);
		},

		_aoCoincidirRota: function(){
			this.exibirEspera(async () => {
				await this._obterEnumeradores();
				await this._obterTodos();
				this._inicializarModelo();
			});
		},

		_obterEnumeradores: function(){
			return AuxiliaresRepositorio
			.obterEnumeradores()
			.then(response => this._definirDadosAuxiliares(response));
		},

		_obterTodos: function(filtro){
			return CarroRepositorio
			.obterTodos(filtro)
			.then(carros => this._definirCarros(carros));
		},

		aoClicarEmFiltrar: function(){
			this.exibirEspera(() => this._filtrar());
		},

		aoFiltrarPorModelo: function(){
			this.exibirEspera(() => this._filtrar());
		},

		aoFiltrarPorProprietario: function(){
			this.exibirEspera(() => this._filtrar());
		},

		aoClicarEmLimparFiltros: function(){
			this.exibirEspera(() => {
				this._inicializarModelo();
				return this._obterTodos();
			});
		},
	});

});