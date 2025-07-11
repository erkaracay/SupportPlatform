<template>
  <Listbox v-model="selected" @change="emitChange">
    <div class="relative mt-1 w-52">
      <ListboxButton
        class="relative w-full cursor-pointer rounded border border-gray-300 bg-white py-2 pl-3 pr-10 text-left shadow-sm focus:outline-none focus:ring-2 focus:ring-primary">
        <span class="block truncate">
          {{ priorityLabel(modelValue) }}
        </span>
        <span class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-2">
          <ChevronUpDownIcon class="h-5 w-5 text-gray-400" />
        </span>
      </ListboxButton>

      <ListboxOptions
        class="absolute z-10 mt-1 max-h-60 w-full overflow-auto rounded bg-white py-1 text-base shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
        <ListboxOption v-for="option in priorities" :key="option.value" :value="option.value"
          class="relative cursor-pointer select-none py-2 pl-10 pr-4 hover:bg-amber-100">
          <span class="block truncate">{{ option.label }}</span>
        </ListboxOption>
      </ListboxOptions>
    </div>
  </Listbox>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { Listbox, ListboxButton, ListboxOptions, ListboxOption } from '@headlessui/vue'
import { ChevronUpDownIcon } from '@heroicons/vue/20/solid'

const props = defineProps<{
  modelValue: 'Low' | 'Medium' | 'High'
}>()

const emit = defineEmits(['update:modelValue'])

const selected = ref(props.modelValue)

watch(() => props.modelValue, (val) => {
  selected.value = val
})

const isValidPriority = (val: string): val is 'Low' | 'Medium' | 'High' =>
  ['Low', 'Medium', 'High'].includes(val)

const emitChange = (val: string) => {
  if (isValidPriority(val)) {
    selected.value = val
    emit('update:modelValue', val)
  }
}

const priorities = [
  { value: 'Low', label: '🟢 Low' },
  { value: 'Medium', label: '🟡 Medium' },
  { value: 'High', label: '🔴 High' }
]

const priorityLabel = (val: string) =>
  priorities.find(p => p.value === val)?.label ?? val
</script>
