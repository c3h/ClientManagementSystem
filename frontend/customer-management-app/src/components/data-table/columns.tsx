"use client"

import { ColumnDef } from "@tanstack/react-table"
import { ArrowUpDown } from "lucide-react"

import { Button } from "@/components/ui/button"

export type Customer = {
  id: number
  name: string
  cpf: string
  gender: string
  customerTypeDescription: string
  customerStatusDescription: string
}

export const columns: ColumnDef<Customer>[] = [
  {
    accessorKey: "name",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Name
          <ArrowUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
  },
  {
    accessorKey: "cpf",
    header: "CPF",
  },
  {
    accessorKey: "gender",
    header: "Gender",
  },
  {
    accessorKey: "customerTypeDescription",
    header: "Customer Type",
  },
  {
    accessorKey: "customerStatusDescription",
    header: "Customer Status",
  },
]
