$(document).ready(function () {
    var $modalInput = $('#addEventModal');
    var $modalDetails = $('#onClickCalEventModal');

    var $eventId = $('#eventID');
    var $eventTitle = $('#eventTitle');
    var $eventDate = $('#eventDate');
    var $eventTime = $('#eventTime');
    var $eventDuration = $('#eventDuration');

    var $mdTitle = $('#modalDetailsTitle');
    var $mdDescr = $('#modalDetailsDescription');
    var $mdTags = $('#modalDetailsTags');
    var $mdLocation = $('#modalDetailsLocation');

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
            showDescription(calEvent);       
        },

        select: function (start, end, jsEvent, view) {            
            showEventPopup(start, end);
        }
    });

    function clearPopupFormValues() {
        $eventId.val("");
        $eventTitle.val("");
        $eventDate.val("");
        $eventTime.val("");
        $eventDuration.val("");
    }

    function showEventPopup(start, end) {
        $eventDate.val(moment(start, 'DD.MM.YYYY').format('DD-MM-YYYY'));
        $eventTime.val(moment(start, 'DD.MM.YYYY').format('HH:mm'));
        $eventDuration.val(end.diff(start, 'minutes'));
        $modalInput.modal('show');
    }

    function showDescription(calEvent) {
        $mdTitle.html(calEvent.title);
        $mdDescr.html(calEvent.description);
        $mdLocation.html(calEvent.location);
        $mdTags.html(calEvent.tags);

        $modalDetails.modal('show');
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
        $modalInput.modal('hide');
        clearPopupFormValues();
    });
});