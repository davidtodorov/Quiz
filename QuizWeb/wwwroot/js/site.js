$(document).ready(function () {

    let quoteId = $('#quote').attr('quoteId');
    let $author = $('#yesNo p');
    let authorId = $author.attr('authorId');

    $('button#yes').on('click', function () {

        $.post("/home/index/",
            {
                Mode: 'yesNo',
                Answer: 'yes',
                QuoteId: quoteId,
                AuthorId: authorId,
            },
            function (result) {
                _showResult(result);
                window.location.replace("/home/index?mode=yesNo");
            });
    });

    $('button#no').on('click', function () {
        $.post("/home/index/",
            {
                Mode: 'yesNo',
                Answer: 'no',
                QuoteId: quoteId,
                AuthorId: authorId,
            },
            function (result) {
                _showResult(result);
                window.location.replace("/home/index?mode=yesNo");
            });
    });

    function _showResult(result)
    {
        if (result.result === true) {
            alert('Correct! The right answer is ' + result.correctAnswer);
        } else {
            alert('Sorry, you are wrong! The right answer is: ' + result.correctAnswer);
        }
    }
});
