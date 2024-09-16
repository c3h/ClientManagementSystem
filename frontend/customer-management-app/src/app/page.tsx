"use client"

import { useEffect, useState } from "react"
import { useRouter } from "next/navigation"
import { DataTable } from "@/components/data-table/data-table"
import { columns, Customer } from "@/components/data-table/columns"
import { getCustomers } from "@/lib/api"
import { Button } from "@/components/ui/button"

export default function HomePage() {
  const [data, setData] = useState<Customer[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const router = useRouter()

  useEffect(() => {
    async function fetchData() {
      try {
        const customers = await getCustomers()
        setData(customers)
      } catch (error) {
        console.error("Error fetching customers:", error)
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [])

  return (
    <main className="p-4">
      <div className="flex items-center justify-between mb-4">
        <h1 className="text-2xl font-bold">Customer Management</h1>
        <Button onClick={() => router.push("/customers")}>Add Customer</Button>
      </div>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <DataTable columns={columns} data={data} />
      )}
    </main>
  )
}
