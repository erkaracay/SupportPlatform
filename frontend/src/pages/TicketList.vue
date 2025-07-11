<template>
  <div class="max-w-7xl mx-auto p-6 space-y-6">
    <div class="flex justify-between items-center">
      <h1 class="text-2xl font-bold text-primary">Tickets</h1>
      <ViewSwitcher v-model="viewMode" />
    </div>

    <div v-if="isLoading" class="text-gray-500">Loading...</div>

    <!-- Görünümler -->
    <div v-else>
      <!-- Card View -->
      <div v-if="viewMode === 'card'" class="space-y-4">
        <TicketCard v-for="ticket in tickets" :key="ticket.id" :ticket="ticket" />
      </div>

      <!-- Grid View -->
      <div v-else-if="viewMode === 'grid'" class="grid md:grid-cols-2 xl:grid-cols-3 gap-4">
        <TicketCard v-for="ticket in tickets" :key="ticket.id" :ticket="ticket" />
      </div>

      <!-- Table View -->
      <div v-else-if="viewMode === 'table'">
        <TicketTable :tickets="tickets" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { getTickets } from '@/services/ticketService'
import TicketCard from '@/components/ticket/TicketCard.vue'
import TicketTable from '@/components/ticket/TicketTable.vue'
import ViewSwitcher from '@/components/ticket/ViewSwitcher.vue'
import { TicketDto } from '@/types/TicketDto'

const tickets = ref<TicketDto[]>([])
const isLoading = ref(true)
const viewMode = ref<'card' | 'grid' | 'table'>('card')

onMounted(async () => {
  const res = await getTickets()
  tickets.value = res.data
  isLoading.value = false
})
</script>
