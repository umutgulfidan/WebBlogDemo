$(document).ready(function () {
    $(document).on('submit', '.subscribeForm', function (e) {
        e.preventDefault(); // Sayfa yenilemeyi engelle

        var form = $(this); // Hangi formun tetiklendiğini al
        var email = form.find('.emailInput').val();
        var submitButton = form.find('input[type="submit"]');
        var responseMessage = form.siblings('.responseMessage'); // Aynı formun yanındaki mesaj alanını seç

        submitButton.prop('disabled', true).val('Gönderiliyor...');

        $.ajax({
            url: '/NewsLetter/SubscribeMail',
            type: 'POST',
            data: { Mail: email },
            success: function (response) {
                if (response.success) {
                    responseMessage
                        .html('<div class="alert alert-success"><strong>Başarıyla abone oldunuz!</strong></div>')
                        .fadeIn();
                } else {
                    responseMessage
                        .html('<div class="alert alert-danger"><strong>' + response.message + '</strong></div>')
                        .fadeIn();
                }
                form.find('.emailInput').val(''); // Formu temizle
            },
            error: function () {
                responseMessage
                    .html('<div class="alert alert-danger"><strong>Bir hata oluştu. Lütfen tekrar deneyin.</strong></div>')
                    .fadeIn();
            },
            complete: function () {
                submitButton.prop('disabled', false).val('Subscribe');
            }
        });
    });
});
