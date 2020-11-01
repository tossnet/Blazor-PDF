function jsSaveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}


function jsOpenToIframe(iFrameId, byteBase64) {
    //Clear content
    document.getElementById(iFrameId).innerHTML = "";

    var ifrm = document.createElement('iframe');
    ifrm.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    ifrm.style.width = "640px";
    ifrm.style.height = "480px";
    document.getElementById(iFrameId).appendChild(ifrm);
}

function jsOpenIntoNewTab(filename, byteBase64) {
    var blob = b64toBlob(byteBase64);

    var blobURL = URL.createObjectURL(blob);
    window.open(blobURL);

    //let pdfWindow = window.open("")
    //pdfWindow.document.write(
    //    "<iframe width='100%' height='100%' src='data:application/pdf;base64, " + byteBase64 + "'></iframe>"
    //)
}

function b64toBlob(b64Data) {
    sliceSize =  512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    var blob = new Blob(byteArrays, { type: 'application/pdf' });
    return blob;
}