﻿$(document).ready(function () {

    if (document.getElementById('yesNo')) {
        $('#multiChoiceTab').removeClass('active');
        $('#yesNoTab').addClass('active');
    } else if (document.getElementById('multiChoice')) {
        $('#yesNoTab').removeClass('active');
        $('#multiChoiceTab').addClass('active');
    }

    let quoteId = $('#quote').attr('quoteId');

    $('#yesNoTab').on('click', function () {
        window.location.replace("/home/index?mode=yesNo");
    });

    $('#multiChoiceTab').on('click', function() {
        window.location.replace("/home/index?mode=multiChoice");
    })

    $('button#yes').on('click', function () {
        let $author = $('#yesNo p');
        let authorId = $author.attr('authorId');

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

        let $author = $('#yesNo p');
        let authorId = $author.attr('authorId');

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

    $('input[name=submit]').on('click', function () {
        let authorId = $('input[name=author]:checked').attr('authorId');
        $.post("/home/index/",
            {
                Mode: 'yesNo',
                Answer: 'yes',
                QuoteId: quoteId,
                AuthorId: authorId,
            },
            function (result) {
                _showResult(result);
                window.location.replace("/home/index?mode=multiChoice");
            });
    });

    function _showResult(result) {

        if (result.result === true) {
            alert('Correct! The right answer is ' + result.correctAnswer);
        } else {
            alert('Sorry, you are wrong! The right answer is: ' + result.correctAnswer);
        }
    }
});
