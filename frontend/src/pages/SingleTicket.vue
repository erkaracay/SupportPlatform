<template>
  <div class="min-h-screen bg-zinc-50 py-10 px-4">
    <div class="max-w-6xl mx-auto p-6 bg-white rounded-lg shadow-md">
      <!-- Başlık ve Aksiyonlar -->
      <div class="flex justify-between items-center mb-6">
        <h1 class="text-2xl font-bold text-primary">
          {{ ticket?.title || 'Loading...' }}
        </h1>

        <div class="space-x-2">
          <button class="bg-gray-100 text-gray-700 px-4 py-2 rounded hover:bg-gray-200">
            Edit
          </button>
          <button class="bg-gray-100 text-gray-700 px-4 py-2 rounded hover:bg-gray-200">
            Comment
          </button>
        </div>
      </div>

      <!-- İçerik -->
      <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
        <!-- Ana İçerik -->
        <div class="md:col-span-2 space-y-6">
          <div>
            <h2 class="text-sm font-semibold text-gray-500 uppercase mb-1">Description</h2>
            <p class="text-gray-700">{{ ticket?.description }}</p>
          </div>


          <StatusSelect v-model="selectedStatus" @update:modelValue="updateStatus" />
          <PrioritySelect v-model="selectedPriority" @update:modelValue="updatePriority" />
        </div>

        <!-- Metadata -->
        <aside class="space-y-6">
          <div>
            <h2 class="text-sm font-semibold text-gray-500 uppercase mb-1">Dates</h2>
            <p class="text-sm text-gray-600">
              <span class="font-medium">Created:</span> {{ formatDate(ticket?.createdAt) }}
            </p>
            <p class="text-sm text-gray-600">
              <span class="font-medium">Updated:</span> Just now
            </p>
          </div>

          <div>
            <h2 class="text-sm font-semibold text-gray-500 uppercase mb-1">People</h2>
            <p class="text-sm text-gray-600">
              <span class="font-medium">Assigned:</span> Unassigned
            </p>
            <p class="text-sm text-gray-600">
              <span class="font-medium">Reporter:</span> You
            </p>
          </div>
        </aside>
      </div>

      <!-- Geri Dön -->
      <div class="mt-10">
        <router-link to="/tickets" class="text-primary hover:underline">
          ← Back to Tickets
        </router-link>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { getTicket, updateTicket } from '@/services/ticketService'
import StatusSelect from '@/components/ticket/StatusSelect.vue'
import PrioritySelect from '@/components/ticket/PrioritySelect.vue'
import type { TicketDto } from '@/types/TicketDto'

const route = useRoute()
const ticket = ref<TicketDto | null>(null)

const selectedStatus = ref<TicketDto['status']>('Open')
const selectedPriority = ref<TicketDto['priority']>('Medium')

onMounted(async () => {
  const res = await getTicket(route.params.id as string)
  ticket.value = res.data
  selectedStatus.value = res.data.status
  selectedPriority.value = res.data.priority
})

const formatDate = (date?: string) =>
  date
    ? new Date(date).toLocaleDateString('en-GB', {
      day: '2-digit',
      month: 'short',
      year: 'numeric',
    })
    : '—'

const updateStatus = async () => {
  if (!ticket.value) return
  await updateTicket(ticket.value.id, { status: selectedStatus.value })
  ticket.value.status = selectedStatus.value
}

const updatePriority = async () => {
  if (!ticket.value) return
  await updateTicket(ticket.value.id, { priority: selectedPriority.value })
  ticket.value.priority = selectedPriority.value
}
</script>
