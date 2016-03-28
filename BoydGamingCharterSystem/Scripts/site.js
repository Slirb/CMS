function removeNestedForm(element, container, deleteElement) {
    $container = $(element).parents(container);
    $container.find(deleteElement).val('True');
    $container.hide();
}