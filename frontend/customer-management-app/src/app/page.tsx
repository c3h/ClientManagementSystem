// app/page.tsx

"use client"

import { useEffect, useState } from "react"
import { DataTable } from "../components/data-table/data-table"
import { columns, Customer } from "../components/data-table/columns"
import { getCustomers } from "../lib/api"

export default function HomePage() {
  const [data, setData] = useState<Customer[]>([])
  const [loading, setLoading] = useState<boolean>(true)

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
      <h1 className="text-2xl font-bold mb-4">Customer Management</h1>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <DataTable columns={columns} data={data} />
      )}
    </main>
  )
}
