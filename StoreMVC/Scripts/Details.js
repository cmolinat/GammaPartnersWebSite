$(document).ready(function () {

    var JobId = $('#JobId').val();

    getJobComments();

    function getJobComments() {

        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Store/GetCommentsByJob',
            contentType: 'application/html; charset=utf-8',
            data: {
                JobId: JobId
            },
            beforeSend: function () {
            },
            error: function (e, x, m) {

            },
            success: function (r) {
                $('#dvComments').html(r);
            }
        });

    }

    $("#btnAddComment").click(function (e) {
        e.preventDefault();
        var datos = $(this).closest('tr').find('.meta').data('md');
        setTimeout(function () {
            $('#md_abc').off('shown.bs.modal').modal('show').on('shown.bs.modal', function (e) {


            });
        }, 500)
        return false;
    });

    $("#btnSaveComment").click(function myfunction() {
        var JobId = $('#JobId').val();
        $.ajax({
            url: '/Store/Comment',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                comment:
                    {
                        Id: '0',
                        SubmittedBy: $('#SubmittedBy').val(),
                        Comment: $('#Comment').val(),
                        JobId: JobId,
                        Rating: '5'
                    }
            }),
            success: function (resp) {
                if (!resp.Error) {
                    $('#md_abc .close').click();
                    getJobComments();


                } else {
                    alert(resp.Message);
                }
                return false;
            }
        })

    });
});