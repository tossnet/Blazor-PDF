function saveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}


function OpenToIframe(iFrameId, byteBase64) {
    //Clear content
    document.getElementById(iFrameId).innerHTML = "";

    var ifrm = document.createElement('iframe');
    ifrm.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    ifrm.style.width = "640px";
    ifrm.style.height = "480px";
    document.getElementById(iFrameId).appendChild(ifrm);
}

function OpenIntoNewTab(filename, byteBase64) {
    let pdfWindow = window.open("")
    pdfWindow.document.write(
        "<iframe width='100%' height='100%' src='data:application/pdf;base64, " + byteBase64 + "'></iframe>"
    )
}