export function addCloseEventListener(dialog, dotnet) {
    dialog.addEventListener("close", () => {
        dotnet.invokeMethodAsync("OnDialogClosed")
    })
}

export function showDialog(dialog) {
    return dialog.showModal()
}

export function closeDialog(dialog) {
    return dialog.close()
}
