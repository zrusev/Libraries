const generator = (function() {
  function load(id, file) {
    $(id).append(provider.getFile(file));
  }

  function loadService(id, service) {
    this.empty(id);
    service();
  }

  function empty(id) {
    $(id).empty();
  }

  return {
    load: load,
    loadService: loadService,
    empty: empty
  }
}) ()