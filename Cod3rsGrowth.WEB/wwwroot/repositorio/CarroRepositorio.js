sap.ui.define([
    './RepositorioBase'
], (RepositorioBase) => {
	"use strict";

    const CONTROLLER_NAME = "Carro";

	return {
		obterTodos: function(filtros) {
			return RepositorioBase.get(CONTROLLER_NAME, filtros);
		}
	};
});

