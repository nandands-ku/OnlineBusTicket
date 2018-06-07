$(document).ready(function () {
    var settings = {
        rows: 10,
        cols: 4,
        rowCssPrefix: 'row-',
        colCssPrefix: 'col-',
        seatWidth: 35,
        seatHeight: 35,
        seatCss: 'seat',
        selectedSeatCss: 'selectedSeat',
        selectingSeatCss: 'selectingSeat'
    };


    var init = function (reservedSeat) {
        var str = [], seatNo, className;
        for (i = 0; i < settings.rows; i++) {
            for (j = 0; j < settings.cols; j++) {
                seatNo = (i * settings.cols + j + 1);
                className = settings.seatCss + ' ' + settings.rowCssPrefix + i.toString() + ' ' + settings.colCssPrefix + j.toString();
                if ($.isArray(reservedSeat) && $.inArray(seatNo, reservedSeat) != -1) {
                    className += ' ' + settings.selectedSeatCss;
                }

                str.push('<li class="' + className + '"' +
                    'style="top:' + (i * settings.seatHeight).toString() + 'px;left:' + (j * settings.seatWidth).toString() + 'px">' +
                    '<a title="' + seatNo + '">' + seatNo + '</a>' +
                    '</li>');
            }
        }
        $('#place').html(str.join(''));
    };
    //case I: Show from starting
    //init();
    //Case II: If already booked
    var bookedSeats = @Html.Raw(Json.Encode(ViewBag.SeatList));
    // var bookedSeats = [5, 10, 25];
    init(bookedSeats);
    var noOfSelectedSeat = 0;

    $('.' + settings.seatCss).click(function () {
        debugger;

        if ($(this).hasClass(settings.selectedSeatCss)) {
            alert('This seat is already reserved');
        }
        else {
            $(this).toggleClass(settings.selectingSeatCss);
            noOfSelectedSeat++;
        }

        var totalFare = noOfSelectedSeat * 1000;
        $("#totalFare").text(totalFare);
        var str = [], item;
        $.each($('#place li.' + settings.selectingSeatCss + ' a'), function (index, value) {
            item = $(this).attr('title');
            str.push(item);
        });

        $("#selectedSeats").text(str.join(','));
    });

    $('#btnShow').click(function () {

        var str = [];
        $.each($('#place li.' + settings.selectedSeatCss + ' a, #place li.' + settings.selectingSeatCss + ' a'), function (index, value) {
            str.push($(this).attr('title'));
        });
        alert(str.join(','));
    })

    $('#btnShowNew').click(function () {

        var str = [], item;
        $.each($('#place li.' + settings.selectingSeatCss + ' a'), function (index, value) {
            item = $(this).attr('title');
            str.push(item);
        });
        alert(str.join(','));
    })

});

