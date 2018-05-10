$(document).ready(function () {

    
    $("select").each(function () {
        setBackgroundColor($(this));
    });

    
    $("select option").each(function () {
        setBackgroundColor($(this));
    });

   
    function setBackgroundColor(object) {
        var color = "black";
       
        switch (object.attr('id')) {
            case "drpBandA":
                SetFigureBandColor($("#firstBand"), object);
                break;
            case "drpBandB":
                SetFigureBandColor($("#secondBand"), object);
                break;
            case "drpBandC":
                SetFigureBandColor($("#thirdBand"), object);
                break;
            case "drpBandD":
                SetFigureBandColor($("#fourthBand"), object);
                break;                
            default:
        }

        
        if (object.val() != '') {

            object.css('background-color', object.val());

            switch (object.val()) {
                case "black":
                    color = "white";
                    break;
                case "red":
                    color = "white";
                    break;
                case "green":
                    color = "white";
                    break;
                case "brown":
                    color = "white";
                    break;
                case "blue":
                    color = "white";
                    break;
                case "gray":
                    color = "white";
                    break;
                default:

            }
            object.css('color', color);
        }
    }

   
    function SetFigureBandColor(figureObject, selectObj) {
        var className = figureObject.attr('class').split(' ');
        figureObject.addClass(selectObj.val()).removeClass(className[1]);
    }

    
    $("select").change(function () {

        setBackgroundColor($(this));

        var data = JSON.stringify({
            'bandAColor': $('#drpBandA').val(),
            'bandBColor': $('#drpBandB').val(),
            'bandCColor': $('#drpBandC').val(),
            'bandDColor': $('#drpBandD').val()
        });

        
        $.ajax({
            type: "POST",
            url: "/Home/getResistanceValue",
            contentType: "application/json;",
            dataType: "json",
            data: data,
            success: function (result) {
                
                if (result.error != undefined) {
                    $("#errorDiv").html(result.error);
                }
                else {
                    $("#errorDiv").empty();
                    $("#txtMinimumResistance").val(result.min);
                    $("#txtMaximumResistance").val(result.max);
                    
                }
            }
        });
    });

})
