"use client"

import { ColumnDef } from "@tanstack/react-table"
import { ArrowUpDown } from "lucide-react"

import { Button } from "@/components/ui/button"

import { useRouter } from "next/navigation"
import { Edit, Trash } from "lucide-react"
import { deleteCustomer } from "../../lib/api"

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
  {
    id: "actions",
    header: "Actions",
    cell: ({ row }) => {
      const router = useRouter()
      const customer = row.original

      const handleEdit = () => {
        router.push(`/customers/${customer.id}`)
      }

      const handleDelete = () => {
        if (confirm(`Are you sure you want to delete ${customer.name}?`)) {
          deleteCustomer(customer.id)
            .then(() => {
              alert("Customer deleted successfully.")
              router.refresh()
            })
            .catch((error) => {
              console.error("Error deleting customer:", error)
              alert("An error occurred while deleting the customer.")
            })
        }
      }

      return (
        <div className="flex space-x-2">
          <Button variant="outline" size="sm" onClick={handleEdit}>
            <Edit className="h-4 w-4" />
          </Button>
          <Button variant="destructive" size="sm" onClick={handleDelete}>
            <Trash className="h-4 w-4" />
          </Button>
        </div>
      )
    },
  },
]