export default class ModalParameters {
  constructor (data) {
    this.id = data.id
    this.mode = data.mode
  }

  // Zwraca refno w postaci long lub guid albo null jeśli nie zaznaczono wiersza
  getId () {
    return this.id
  }

  setAddMode () {
    this.mode = 'add'
  }

  setEditMode () {
    this.mode = 'edit'
  }

  setFastEditMode () {
    this.mode = 'fastEdit'
  }

  setCopyMode () {
    this.mode = 'copy'
  }

  setViewMode () {
    this.mode = 'view'
  }

  isAddMode () {
    return this.mode === 'add'
  }

  isEditMode () {
    return this.mode === 'edit'
  }

  isFastEditMode () {
    return this.mode === 'fastEdit'
  }

  isCopyMode () {
    return this.mode === 'copy'
  }

  isViewMode () {
    return this.mode === 'view'
  }
}
