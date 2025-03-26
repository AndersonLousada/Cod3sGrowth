sap.ui.define([
	'sap/ui/core/mvc/Controller',
	'sap/ui/core/BusyIndicator',
    'sap/m/MessageBox',
],
	function(Controller, BusyIndicator, MessageBox) {
	"use strict";

	return Controller.extend("coders.growth.app.BaseController", {

        modelo: function(nome, dados){
			return dados ?
				this.getView().setModel(dados, nome) :
				this.getView().getModel(nome)
		},

		_exibirMsgDeErro: function(ex) {
			MessageBox.error(`Erro: ${ex.message}`);
			console.log(`Detalhes do erro: ${ex.stack}`);
		},

		exibirEspera : function (func) {
			try {
				BusyIndicator.show(0);
				return Promise.resolve()
					.then(() => func())
					.catch(x => this._exibirMsgDeErro(x))
					.finally(() => BusyIndicator.hide());
			} catch (ex) {
				this._exibirMsgDeErro(ex);
			}
		},

	});

});