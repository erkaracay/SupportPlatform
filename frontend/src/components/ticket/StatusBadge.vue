<template>
  <span :class="[
    'px-2 py-1 rounded text-xs font-medium',
    statusColor
  ]">
    {{ status }}
  </span>
</template>

<script setup lang="ts">
const props = defineProps<{
  status: 'Open' | 'InProgress' | 'Closed'
}>()

const statusColor = {
  Open: 'bg-green-100 text-green-700',
  InProgress: 'bg-amber-100 text-amber-700',
  Closed: 'bg-gray-200 text-gray-700'
}[props.status]
</script>
