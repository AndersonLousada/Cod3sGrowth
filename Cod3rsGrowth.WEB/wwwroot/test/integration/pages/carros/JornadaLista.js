sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Lista"
], function (opaTest) {
	"use strict";

	QUnit.module("TelaDeListagem", () => {

		opaTest("Tela de listagem deve ser carregada com sucesso", function (Given, When, Then) {
			// Arrangements
			Given.iStartMyApp();

			// Assertions
			Then.
				naPaginaDeListagemDeVeiculos.
				paginaFoiCarregadaConformeEsperado().
				and.
				listaPossuiTituloEsperado().
				and.
				listaNaoDeveEstarVazia().
				and.
				filtroModeloDeveEstarVazio().
				and.
				filtroProprietarioDeveEstarVazio();

			// Cleanup
			Then.iTeardownMyApp();
		});
	});

});