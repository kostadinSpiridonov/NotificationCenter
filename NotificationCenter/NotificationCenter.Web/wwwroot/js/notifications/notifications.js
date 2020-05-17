
$(document).ready(function () {

    setupSignalR();
    setupEvents();

    function setupEvents() {
        $("#simulate").click(function () {
            $.ajax({
                type: "POST",
                url: "Notification/SimulateRequestUpdate"
            });
        });
    }

    function setupSignalR() {
        var connection = new signalR
            .HubConnectionBuilder()
            .withUrl("/notificationhub")
            .build();

        connection.start();
        connection.on("ReceiveNotification", appendNotification);
    }

    function appendNotification(message) {
        $("#notifications").append("<tr><td>" + message + "</td></tr>");
    }
});
