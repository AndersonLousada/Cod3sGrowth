sap.ui.define([
	'sap/ui/test/Opa5'
],
function (Opa5) {
	"use strict";

	const VIEW_NAME = ".carros.Lista";

	Opa5.createPageObjects({
		naPaginaDeListagemDeVeiculos: {
			actions: {
				
			},

			assertions: {
				listaDeVeiculosFoiCarregadaConformeEsperado: function () {
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

				listaDeveEstarCarregada: function () {
					return this.waitFor({
						controlType: "sap.m.List",
						viewName: VIEW_NAME,
						i18NText: {
							propertyName: "headerText",
							key: "TelaDeListagem.Veiculos"
						},
						success: function (lista) {
							Opa5.assert.ok(true, "Lista de veículos foi carregada conforme esperado");
						}
					});
				}
			}
		}
	});

});
