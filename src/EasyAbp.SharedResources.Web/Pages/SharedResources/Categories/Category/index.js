$(function () {

    var l = abp.localization.getResource('EasyAbpSharedResources');

    var service = easyAbp.sharedResources.categories.category;
    var createModal = new abp.ModalManager(abp.appPath + 'SharedResources/Categories/Category/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SharedResources/Categories/Category/EditModal');

    var dataTable = $('#CategoryTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function () {
            return { ownerUserId: ownerUserId, rootCategoryId: rootCategoryId };
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Resource'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.Resource'),
                                action: function (data) {
                                    document.location.href = document.location.origin + '/SharedResources/Resources/Resource?CategoryId=' + data.record.id;
                                }
                            },
                            {
                                text: l('SubCategory'),
                                action: function (data) {
                                    document.location.href = document.location.origin + '/SharedResources/Categories/Category?OwnerUserId=' + ownerUserId + '&RootCategoryId=' + data.record.id;
                                }
                            },
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.Category.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.Category.Delete'),
                                confirmMessage: function (data) {
                                    return l('CategoryDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "name" },
            { data: "customMark" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCategoryButton').click(function (e) {
        e.preventDefault();
        createModal.open({ parentCategoryId: rootCategoryId });
    });
});