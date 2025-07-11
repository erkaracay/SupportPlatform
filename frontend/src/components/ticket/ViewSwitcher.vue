<template>
  <div class="flex items-center gap-2">
    <button v-for="view in views" :key="view.value" :title="view.label" @click="$emit('update:modelValue', view.value)"
      :class="[
        'p-2 rounded border transition',
        modelValue === view.value
          ? 'bg-primary text-white border-primary'
          : 'bg-white border-gray-300 hover:bg-gray-100 text-gray-600'
      ]">
      <component :is="view.icon" class="w-5 h-5" />
    </button>
  </div>
</template>

<script setup lang="ts">
import { defineProps, defineEmits } from 'vue'
import { Squares2X2Icon, RectangleStackIcon, TableCellsIcon } from '@heroicons/vue/24/outline'

defineProps<{ modelValue: 'card' | 'grid' | 'table' }>()
defineEmits(['update:modelValue'])

const views = [
  { value: 'card', label: 'Card View', icon: RectangleStackIcon },
  { value: 'grid', label: 'Grid View', icon: Squares2X2Icon },
  { value: 'table', label: 'Table View', icon: TableCellsIcon }
]
</script>
