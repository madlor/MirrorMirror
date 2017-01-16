// Write your Javascript code.
//var video = document.querySelector("#videoElement");
var video = document.querySelector('video');
var canvas = document.getElementById('imagecanvas');
var captureTimer = setInterval(CaptureFrame, 10000);

navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia || navigator.oGetUserMedia;

if (navigator.getUserMedia) {
    navigator.getUserMedia({video: true}, handleVideo, videoError);
}

function handleVideo(stream) {
    video.src = window.URL.createObjectURL(stream);
}

function videoError(e) {
    // do something
}



function CaptureFrame() {
    //context.drawImage(video, 0, 0, 200, 100);
    canvas = document.getElementById('imagecanvas');
    var context = canvas.getContext('2d');

    context.drawImage(video, 0, 0, video.width, video.height);

    /*
    console.log("click");
    console.log(canvas);
    console.log(context);
    */

    //var image = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");
    //console.log(imagedata);
    
    
    var image = canvas.toDataURL("image/png");
    image = image.replace('data:image/png;base64,', '');
    //console.log(image);

    /*
    console.log(image);
    */
    
    $.ajax({
        type: "POST",
        url: '../../Home/VerifyFace',
        contentType: "application/json",
        dataType: 'application/json',
        data: JSON.stringify(image),
        success: function (result) {
            $("#BottomShard-3").html(result);
            //console.log(result);
        }
    });
    
    
}




// Trigger photo take
document.getElementById("snap").addEventListener("click", function () {
    //context.drawImage(video, 0, 0, 200, 100);
    canvas = document.getElementById('imagecanvas');
    var context = canvas.getContext('2d');
    //context.drawImage(video, 0, 0, video.width, video.height, 0, 0, canvas.width, canvas.height);

    context.drawImage(video, 0, 0, video.width, video.height);

    console.log("click");
    console.log(canvas);
    console.log(context);

    
    /*
    var image = canvas.toDataURL("image/png");

    image = image.replace('data:image/png;base64,', '');
    console.log(image);

    
    $.ajax({
        type: "POST",
        url: '../../Home/VerifyFace',
        contentType: "application/json",
        dataType: 'application/json',
        data: JSON.stringify(image),
        success: function (result) {
            $("#BottomShard-3").html(result);
        }
    });
    */
    
});