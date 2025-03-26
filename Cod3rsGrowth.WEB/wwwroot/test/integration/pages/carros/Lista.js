sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/actions/EnterText',
    "sap/ui/test/actions/Press",
],
function (Opa5, EnterText, Press) {
	"use strict";

	const VIEW_NAME = ".carros.Lista";

	Opa5.createPageObjects({
		naPaginaDeListagemDeVeiculos: {
			actions: {

				informoFiltroModelo: function (texto) {
					return this.waitFor({
						controlType: "sap.m.SearchField",
						viewName: VIEW_NAME,
						matchers: [{
							propertyStrictEquals: {
								name: "placeholder",
								value: "Modelo"
							}
						}],
						actions: new EnterText({ text: texto }),
						success: function (searchField) {
							Opa5.assert.ok(true, `Filtro ${texto} foi informado conforme esperado`);
						}
					});
				},
				
				clicoNoBotaoDeFiltrar: function () {
					this.waitFor({
						controlType: "sap.m.Button",
						viewName: "coders.growth.app.carros.Lista",
						viewId: "container-app---lista",
						matchers: [{
							i18NText: {
								propertyName: "tooltip",
								key: "TelaDeListagem.Filtrar"
							},
							propertyStrictEquals: {
								name: "icon",
								value: "sap-icon://add-filter"
							},
						}],
						actions: new Press(),
						success: function (button) {
							Opa5.assert.ok(true, "Clique no botão ocorreu conforme esperado");
						}
					});
				}
			},

			assertions: {
				paginaFoiCarregadaConformeEsperado: function () {
					return this.waitFor({
						controlType: "sap.m.Page",
						viewName: VIEW_NAME,
						i18NText: {
							propertyName: "title",
							key: "TelaDeListagem.Titulo"
						},
						success: function (title) {
							Opa5.assert.ok(true, "Tela de Lista foi carregada conforme esperado");
						}
					});
				},

				listaPossuiTituloEsperado: function () {
					return this.waitFor({
						controlType: "sap.m.Title",
						viewName: VIEW_NAME,
						i18NText: {
							propertyName: "text",
							key: "TelaDeListagem.Veiculos"
						},
						success: function () {
							Opa5.assert.ok(true, "Lista de veículos foi carregada conforme esperado");
						}
					});
				},

				listaNaoDeveEstarVazia: function () {
					return this.waitFor({
						controlType: "sap.m.List",
						viewName: VIEW_NAME,
						bindingPath: {
							path: "",
							propertyPath: "/",
							modelName: "carros"
						},
						success: function (lista) {
							let possuiMaisDeUmItem = lista[0].getAggregation("items").length >= 1;
							Opa5.assert.ok(possuiMaisDeUmItem, "Lista de possui itens carregados conforme esperado");
						}
					});
				},

				listaDeveEstarVazia: function () {
					return this.waitFor({
						controlType: "sap.m.List",
						viewName: VIEW_NAME,
						bindingPath: {
							path: "",
							propertyPath: "/",
							modelName: "carros"
						},
						success: function (lista) {
							let listaVazia = lista[0].getAggregation("items").length === 0;
							Opa5.assert.ok(listaVazia, "Lista deve estar vazia conforme esperado");
						}
					});	
				},

				filtroModeloDeveEstarVazio: function () {
					return this.waitFor({
						controlType: "sap.m.SearchField",
						viewName: VIEW_NAME,
						matchers: [{
							propertyStrictEquals: {
								name: "placeholder",
								value: "Modelo"
							},
							propertyStrictEquals: {
								name: "value",
								value: ""
							},
						}],
						success: function (searchField) {
							Opa5.assert.ok(true, "Filtro de modelo está vazio conforme esperado");
						}
					});
				},

				filtroProprietarioDeveEstarVazio: function () {
					return this.waitFor({
						controlType: "sap.m.SearchField",
						viewName: VIEW_NAME,
						matchers: [{
							propertyStrictEquals: {
								name: "placeholder",
								value: "Proprietário"
							},
							propertyStrictEquals: {
								name: "value",
								value: ""
							},
						}],
						success: function (searchField) {
							Opa5.assert.ok(true, "Filtro de proprietário está vazio conforme esperado");
						}
					});
				},
			}
		}
	});

});
