<!-- src/App.vue -->
<template>
  <component :is="layout">
    <RouterView v-slot="{ Component }">
      <component :is="Component" />
    </RouterView>
  </component>
</template>

<script setup lang="ts">
import { ref, watchEffect } from 'vue'
import { useRoute } from 'vue-router'
import DefaultLayout from '@/layouts/DefaultLayout.vue'

const route = useRoute()
const layout = ref(DefaultLayout)

watchEffect(() => {
  const matchedComponent = route.matched.at(-1)?.components?.default as any
  layout.value = matchedComponent?.layout || DefaultLayout
})
</script>
