﻿var total = 0.;
/* Localizamos las filas de datos */
var filas = document.querySelectorAll('table tbody tr');
/* Por cada fila sumamos los datos de la primera y segunda columna */
filas.forEach(function (valor, indice) {
    /* Localizamos las celdas de datos */
    var celdas = valor.querySelectorAll('td');
    /* Si son valores numéricos y existe la tercera columna */
    if (
        !isNaN(celdas[1].innerText)
        &&
        !isNaN(celdas[2].innerText)
        &&
        celdas[3] !== undefined
    ) {
        /* Calculamos el producto, mostramos el resultado y lo agregamos al total */
        var suma = parseFloat(celdas[1].innerText) * parseFloat(celdas[2].innerText);
        celdas[3].innerText = ("$" + suma.toFixed(2));
        total += suma;
    }
});
/* Mostramos la salida */
var pie = document.querySelectorAll('table tfoot td');
if (pie[3] !== undefined) {
    pie[3].innerText = ("$" + total.toFixed(2));
}