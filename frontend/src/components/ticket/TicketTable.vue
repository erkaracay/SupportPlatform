<template>
  <table class="min-w-full bg-white border rounded shadow text-sm">
    <thead class="bg-zinc-100 text-left">
      <tr>
        <th class="p-3">Title</th>
        <th class="p-3">Status</th>
        <th class="p-3">Priority</th>
        <th class="p-3">Created At</th>
        <th class="p-3"></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="ticket in tickets" :key="ticket.id" class="border-t hover:bg-zinc-50">
        <td class="p-3 font-medium">{{ ticket.title }}</td>
        <td class="p-3">
          <StatusBadge :status="ticket.status" />
        </td>
        <td class="p-3">
          <PriorityTag :priority="ticket.priority" />
        </td>
        <td class="p-3">{{ formatDate(ticket.createdAt) }}</td>
        <td class="p-3 text-right">
          <RouterLink :to="`/tickets/${ticket.id}`" class="text-blue-500 hover:underline">Details</RouterLink>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import { TicketDto } from '@/types/TicketDto'
import StatusBadge from '@/components/ticket/StatusBadge.vue'
import PriorityTag from '@/components/ticket/PriorityTag.vue'

defineProps<{ tickets: TicketDto[] }>()

const formatDate = (date: string) =>
  new Date(date).toLocaleDateString('en-GB', {
    day: '2-digit',
    month: 'short',
    year: 'numeric'
  })
</script>
