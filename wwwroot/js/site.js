// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

});

function copySampleToInput(inputControl, div) {
    var $input = $("#" + inputControl);

    $input.val(div.innerText);
}

movement = {
    execute: function (inputControl, outputControl) {
        var input = $("#" + inputControl).val();
        if (!input) {
            movement.output(outputControl, "Input field cannot be empty");
            return;
        }

        /* Api Call */
        $.ajax({
            url: '/game/Start',
            datatype: 'application/json; charset=utf-8',
            type: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'input': JSON.stringify(input)
            },  
            success: function (result) {
                movement.applyStep(outputControl, result);
            }
        });
    },
    applyStep: function (outputControl, step) {
        if (!step) {
            movement.output(outputControl, "There is no movement");
            return;
        }

        $("#Pointer").parent().text(".");
        $("#Pointer").remove();


        /* Robot Result */

        // for Icon
        if (step.direction == 90)
            dir = "up";
        if (step.direction == 180)
            dir = "left";
        if (step.direction == 270)
            dir = "down";
        if (step.direction == 360)
            dir = "right";


        $("#yx" + step.y + step.x).html("<i id='Pointer' class='bi bi-arrow-" + dir + "-square-fill fs20'></i>");


        /* Output */
        var outputText =
            " x : " + step.x
            + " y : " + step.y
            + " d : " + step.directionText
            + "\r";

        movement.output(outputControl, outputText);
    },
    output: function (outputControl, text) {
        var output = $("#" + outputControl);
        if (output) {
            output.val(text);
        }
    }
}