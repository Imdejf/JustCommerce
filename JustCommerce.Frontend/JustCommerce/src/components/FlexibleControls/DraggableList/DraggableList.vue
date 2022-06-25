<template>
  <div class="mb-5 pb-3">
    <div class="header-section">
      <h5 class="section-title text-center" style="height:25px">{{ title }}</h5>
      <button
        @click="addEmpty"
        class="btn btn-link text-success position-absolute"
        :disabled="disabled"
        style="width:20px; font-size:20px"
      >
        <i class="fa fa-plus-square mr-2"></i>
      </button>
    </div>
      <draggable
        :list="list"
        group="people"
        @start="drag=true"
        @end="drag=false"
        item-key="id">
        <template #item="{ element }">
            <div>
              <li v-for="(item, index) in element" :key="index"
              class="list-group-item rs-list-group-item d-flex"
              :class="{'rs-list-group-item--current-key' : item === selectedItem,
                       'rs-list-group-item--error': getItemsValidation(item).$invalid}"
               @click="selected(item, index)">
                  <div class="d-flex">
                    <span class="text-truncate">
                      <slot name="item-name" :item="item"></slot>
                    </span>
                    <span class="mx-2" v-if="getItemsValidation(item).$invalid">
                      <i class="fas fa-triangle fa-sm u-font-red"></i>
                    </span>
                  </div>
                  <div class="rs-list-group-item__right">
                    <slot name="item-buttons" :item="item"></slot>
                  </div>
                </li>
            </div>
       </template>
      </draggable>
    <div class="text-center">
      <button
        v-if="syncButton"
        @click="syncFieldsWithTemplate"
        class="btn btn-link text-success mt-1"
        :disabled="disabled"
      >
        Sync fields with template
      </button>
    </div>
  </div>
</template>

<script>
import draggable from 'vuedraggable'

export default {
  props: {
    // required
    list: {
      required: true,
      type: Array
    },
    selected: {
      required: true,
      type: Function
    },
    addEmpty: {
      required: true,
      type: Function
    },
    selectedItem: {
      required: true
    },
    validations: {
      required: false,
      type: Object
    },

    // optional
    title: {
      required: false,
      type: String,
      default: ''
    },
    syncButton: {
      required: false,
      type: Boolean,
      default: false
    },
    syncFieldsWithTemplate: {
      required: false,
      type: Function
    },
    disabled: {
      required: false,
      type: Boolean,
      default: false
    }
  },
  components: {
    draggable
  },
  methods: {
    getItemsValidation: function (item) {
      for (const validation in this.validations.each.$iter) {
        if (this.validations.each.$iter[validation].$model === item) {
          return this.validations.each.$iter[validation]
        }
      }
      return {}
    }
  }
}
</script>

<style lang="scss" scoped>
.header-section {
  position: relative;
  button {
    position: absolute;
    margin: 0;
    padding: 0;
    right: 0;
    top: -1px;
  }
}
</style>
