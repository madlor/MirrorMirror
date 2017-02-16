var video = document.querySelector('video');
var canvas = document.getElementById('imagecanvas');
var captureTimer = setInterval(CaptureFrame, 10000);

navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia || navigator.oGetUserMedia;

if (navigator.getUserMedia) {
    navigator.getUserMedia({ video: true }, handleVideo, videoError);
}

function handleVideo(stream) {
    video.src = window.URL.createObjectURL(stream);
}

function videoError(e) {
    // do something
}



function CaptureFrame() {
    canvas = document.getElementById('imagecanvas');
    var context = canvas.getContext('2d');

    context.drawImage(video, 0, 0, video.width, video.height);

    var image = canvas.toDataURL("image/png");
    image = image.replace('data:image/png;base64,', '');

    $.ajax({
        type: "POST",
        url: '../../Home/VerifyFace',
        contentType: "application/json",
        dataType: 'json',
        data: JSON.stringify(image),
        success: function (data) {
            $("#BottomShard-3").html(data);
        }
    });
}