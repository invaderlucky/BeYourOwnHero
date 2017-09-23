var PrintPlugin = {
  PrintFrameJs: function(img, size) {
    var binary = '';
    for (var i = 0; i < size; i++)
      binary += String.fromCharCode(HEAPU8[img + i]);
    var dataUrl = 'data:image/png;base64,' + btoa(binary);
    console.log("From plugin: " + dataUrl);
    return dataUrl;
  },
};
mergeInto(LibraryManager.library, PrintPlugin);