"use client"

import { useEffect, useState } from "react"
import { useRouter } from "next/navigation"
import { DataTable } from "@/components/data-table/data-table"
import { columns, Customer } from "@/components/data-table/columns"
import { getCustomers, getCustomerById } from "@/lib/api"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"

export default function HomePage() {
  const [data, setData] = useState<Customer[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [searchId, setSearchId] = useState<string>("")
  const router = useRouter()

  useEffect(() => {
    fetchData()
  }, [])

  const fetchData = async () => {
    setLoading(true)
    try {
      const customers = await getCustomers()
      setData(customers)
    } catch (error) {
      console.error("Error fetching customers:", error)
    } finally {
      setLoading(false)
    }
  }

  const handleSearch = async (e: React.FormEvent) => {
    e.preventDefault()
    if (searchId.trim() === "") {
      fetchData()
      return
    }

    setLoading(true)
    try {
      const customerId = parseInt(searchId, 10)
      if (isNaN(customerId)) {
        alert("Por favor, insira um ID válido")
        setLoading(false)
        return
      }
      const customer = await getCustomerById(customerId)
      setData([customer])
    } catch (error) {
      console.error("Error fetching customer:", error)
      alert("Cliente não encontrado")
      setData([])
    } finally {
      setLoading(false)
    }
  }

  return (
    <main className="p-4">
      <div className="flex items-center justify-between mb-4">
        <h1 className="text-2xl font-bold">Customer Management</h1>
      </div>
      <div className="flex items-center justify-between mb-4">
        <form onSubmit={handleSearch} className="flex items-center space-x-2">
          <Input
            placeholder="Search by ID"
            value={searchId}
            onChange={(e) => setSearchId(e.target.value)}
          />
          <Button type="submit">Search</Button>
        </form>
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
