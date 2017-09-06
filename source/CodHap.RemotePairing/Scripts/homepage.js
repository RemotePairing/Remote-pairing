$(document).ready(function () {
    var $modal = $('#myModal');

    var $eventId = $('#eventID');
    var $eventTitle = $('#eventTitle');
    var $eventDate = $('#eventDate');
    var $eventTime = $('#eventTime');
    var $eventDuration = $('#eventDuration');

    $('#calendar').fullCalendar({
        header: {
            left: 'prev, next today',
            center: 'title',
            right: 'month, agendaWeek, agendaDay'
        },
        height: 'auto',
        defaultView: 'agendaWeek',
        editable: true,
        events: {
            url: '/Home/GetEvents/',
            cache: true
        },
        allDaySlot: false,
        selectable: true,
        slotMinutes: 15,
        eventClick: function (calEvent, jsEvent, view) {
            alert('You clicked on event id: ' +
                calEvent.Id +
                "\nStart: " +
                calEvent.start.format('DD-MM-YYYY HH:mm') +
                "\nEnd: " +
                calEvent.end.format('DD-MM-YYYY HH:mm') +
                "\nTitle: " +
                calEvent.title);
        },
        //dayClick: function(date, jsEvent, view) {
        //    $eventDate.val(moment(date, 'DD.MM.YYYY').format('DD-MM-YYYY'));
        //    $eventTime.val(moment(date, 'DD.MM.YYYY').format('HH:MM'));
        //    ShowEventPopup();
        //},
        select: function (start, end, jsEvent, view) {
            $eventDate.val(moment(start, 'DD.MM.YYYY').format('DD-MM-YYYY'));
            $eventTime.val(moment(start, 'DD.MM.YYYY').format('HH:mm'));
            ShowEventPopup();
        }
    });

    function ClearPopupFormValues() {
        $eventId.val("");
        $eventTitle.val("");
        $eventDate.val("");
        $eventTime.val("");
        $eventDuration.val("");
    }

    function ShowEventPopup() {
        $modal.modal('show');
    }

    $('#saveDate').click(function () {
        var data = {
            name: $eventTitle.val(),
            startDate: $eventDate.val(),
            time: $eventTime.val(),
            duration: $eventDuration.val()
        };
        console.log(data);

        $.ajax({
            type: 'POST',
            url: "/Home/AddEvent",
            data: data,
            success: function (response) {
                if (response == 'True') {
                    $('#calendar').fullCalendar('refetchEvents');
                } else {
                    alert('Error, could not save event!');
                }
            }
        });
        $modal.modal('hide');
    });
});