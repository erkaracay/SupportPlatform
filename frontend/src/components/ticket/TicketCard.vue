<template>
  <div class="bg-white border border-zinc-200 rounded-md shadow-sm p-5 hover:shadow-md hover:bg-zinc-50 ring-primary/5 transition space-y-3">
    <div class="flex justify-between items-start">
      <h3 class="text-base font-semibold text-zinc-900 line-clamp-1">
        {{ ticket.title }}
      </h3>

      <div class="flex gap-2 items-center">
        <StatusBadge :status="ticket.status" />
        <PriorityTag :priority="ticket.priority" />
      </div>
    </div>

    <p class="text-zinc-600 text-sm line-clamp-2 min-h-[3rem]">
      {{ ticket.description }}
    </p>

    <div class="flex justify-between items-center text-xs text-zinc-500">
      <div class="flex flex-wrap gap-3 items-center">
        <span>Created: {{ formatDate(ticket.createdAt) }}</span>
        <span>ID: {{ ticket.id.slice(0, 6) }}</span>
      </div>

      <RouterLink :to="`/tickets/${ticket.id}`" class="text-amber-600 hover:underline font-medium">
        View →
      </RouterLink>
    </div>
  </div>
</template>

<script setup lang="ts">
import { TicketDto } from '@/types/TicketDto'
import StatusBadge from '@/components/ticket/StatusBadge.vue'
import PriorityTag from '@/components/ticket/PriorityTag.vue'

defineProps<{ ticket: TicketDto }>()

const formatDate = (date: string) =>
  new Date(date).toLocaleDateString('en-GB', {
    day: '2-digit',
    month: 'short',
    year: 'numeric'
  })
</script>
