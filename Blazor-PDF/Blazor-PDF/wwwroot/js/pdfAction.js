function jsDownloadFile(filename, content) {
    const file = new File([content], filename, { type: "application/octet-stream" });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object url, let's release the memory
    URL.revokeObjectURL(exportUrl);
}


function jsOpenToIframe(iFrameId, byteBase64) {
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