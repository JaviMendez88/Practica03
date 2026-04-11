$(document).ready(function () {

    $("#IdCompra").change(function () {
        var idCompra = $(this).val();

        if (idCompra !== "") {
            $.getJSON("/Abonos/ObtenerSaldo", { id: idCompra }, function (data) {
                $("#SaldoAnterior").val(data);
            });
        } else {
            $("#SaldoAnterior").val("");
        }
    });

    $("form").submit(function () {
        var saldo = parseFloat($("#SaldoAnterior").val());
        var abono = parseFloat($("#MontoAbono").val());

        if (abono > saldo) {
            alert("El abono no puede ser mayor al saldo");
            return false;
        }
    });

});