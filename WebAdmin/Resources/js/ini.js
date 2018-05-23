$(document).ready(function () {
    $("body").on('click', 'button', function () {

        // Si el boton no tiene el atributo ajax no hacemos nada
        if ($(this).data('ajax') == undefined) return;

        // El metodo .data identifica la entrada y la castea al valor más correcto
        if ($(this).data('ajax') != true) return;

        var form = $(this).closest("form");
        var buttons = $("button", form);
        var button = $(this);
        var url = form.attr('action');

        if (button.data('confirm') != undefined)
        {
            if (button.data('confirm') == '') {
                if (!confirm('¿Esta seguro de realizar esta acción?')) return false;
            } else {
                if (!confirm(button.data('confirm'))) return false;
            }
        }

        if (!form.valid())
        {
            return false;
        }

        // Creamos un div que bloqueara todo el formulario
        var block = $('<div class="block-loading" />');
        form.prepend(block);

        // En caso de que haya habido un mensaje de alerta
        $(".alert", form).remove();

        form.ajaxSubmit({
            dataType: 'JSON',
            type: 'POST',
            url: url,
            success: function (r) {
                block.remove();
                if (r.Response) {
                    if (button.data('success') != undefined) {
                        setTimeout(button.data('success'), 0);
                    }

                    if (!button.data('reset') != undefined) {
                        if (button.data('reset')) form.reset();
                    }
                    else
                    {
                        form.find('input:file').val('');
                    }
                }

                // Mostrar mensaje
                if (r.Message != null) {
                    if (r.Message.length > 0) {
                        var css = "";
                        if (r.Response) css = "alert-success";
                        else css = "alert-danger";

                        var alert = $('<div class="alert ' + css + ' alert-dismissable">');
                        alert.append(r.Message);

                        if (r.Errors.length > 0)
                        {
                            var ul = $("<ul>");
                            r.Errors.forEach(function (x) {
                                ul.append('<li>' + x + '</li>');
                            })

                            alert.append(ul);
                        }

                        form.prepend(alert);
                    }
                }

                // Ejecutar funciones
                if (r.Function != null) {
                    setTimeout(r.Function, 0);
                }
                // Redireccionar
                if (r.Href !== null) {
                    if (r.Href === 'self') window.location.reload(true);
                    else window.location.href = r.Href;
                }
            },
            error: function(jqXHR, textStatus, errorThrown){
                block.remove();
                form.prepend('<div class="alert alert-warning alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + errorThrown + ' | <b>' + textStatus + '</b></div>');
            }
        });

        return false;
    })
})

function _plugins() {
    $("input.datepicker").datepicker({
        format: 'dd/mm/yyyy'
    });
}

jQuery.fn.reset = function () {
    $("input:password,input:file,input:text,textarea", $(this)).val('');
    $("input:checkbox:checked", $(this)).click();
    $("select").each(function () {
        $(this).val($("option:first", $(this)).val());
    })
};