$(document).ready(function () {

    $("#IdCompra").change(function () {
        var idSeleccionado = $(this).val();

        if (idSeleccionado) {
            $.ajax({
                url: '/Abonos/ObtenerSaldo',
                type: 'GET',
                data: { id: idSeleccionado },
                success: function (saldo) {
                    $("#SaldoAnterior").val(saldo);
                },
                error: function () {
                    alert("Hubo un error de comunicación con el servidor al cargar el saldo.");
                }
            });
        } else {
            $("#SaldoAnterior").val('');
        }
    });

    $("form").submit(function (e) {
        var saldoAnterior = parseFloat($("#SaldoAnterior").val());
        var montoAbono = parseFloat($("#MontoAbono").val());

        if (isNaN(saldoAnterior)) {
            alert("Por favor seleccione una compra primero.");
            e.preventDefault();
            return;
        }

        if (isNaN(montoAbono) || montoAbono <= 0) {
            alert("Debe ingresar un monto de abono mayor a 0.");
            e.preventDefault();
            return;
        }

        if (montoAbono > saldoAnterior) {
            alert("Error: El monto a abonar (" + montoAbono + ") no puede ser mayor al saldo actual (" + saldoAnterior + ").");
            $("#MontoAbono").focus();
            e.preventDefault();
        }
    });
});