<template>
  <span :class="[
    'px-2 py-1 rounded text-xs font-medium border',
    priorityColor
  ]">
    {{ priority }}
  </span>
</template>

<script setup lang="ts">
const props = defineProps<{
  priority: 'Low' | 'Medium' | 'High'
}>()

const priorityColor = {
  Low: 'text-gray-600 border-gray-400',
  Medium: 'text-amber-600 border-amber-500',
  High: 'text-red-600 border-red-500'
}[props.priority]
</script>
