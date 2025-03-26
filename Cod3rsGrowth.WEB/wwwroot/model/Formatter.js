sap.ui.define([], () => {
	"use strict";

	return {
		formatarAno(data) {
			let ano = new Date(data).getFullYear();
            return ano;
		},

		formatarCombustivel(combustivelEnum, descriptions) {
            return descriptions[combustivelEnum];
		}
	};
});