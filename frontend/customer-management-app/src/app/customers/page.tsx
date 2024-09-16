"use client"

import { useEffect, useState } from "react"
import { useRouter } from "next/navigation"
import axios from "axios"
import { CustomerStatus, CustomerType } from "../types"
import { getCustomerStatuses, getCustomerTypes, createCustomer } from "@/lib/api"
import { Input } from "../../components/ui/input"
import { Button } from "../../components/ui/button"
import { Label } from "../../components/ui/label"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "../../components/ui/select"

export default function NewCustomerPage() {
  const [name, setName] = useState("")
  const [cpf, setCpf] = useState("")
  const [gender, setGender] = useState("")
  const [customerTypeId, setCustomerTypeId] = useState<number | null>(null)
  const [customerStatusId, setCustomerStatusId] = useState<number | null>(null)
  const [customerTypes, setCustomerTypes] = useState<CustomerType[]>([])
  const [customerStatuses, setCustomerStatuses] = useState<CustomerStatus[]>([])
  const [loading, setLoading] = useState(false)
  const router = useRouter()

  useEffect(() => {
    async function fetchData() {
      try {
        const [types, statuses] = await Promise.all([
          getCustomerTypes(),
          getCustomerStatuses(),
        ])
        setCustomerTypes(types)
        setCustomerStatuses(statuses)
      } catch (error) {
        console.error("Error fetching data:", error)
      }
    }

    fetchData()
  }, [])

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setLoading(true)

    try {
      await createCustomer({
        name,
        cpf,
        gender,
        customerTypeId: customerTypeId!,
        customerStatusId: customerStatusId!,
      })
      router.push("/")
    } catch (error) {
      console.error("Error creating customer:", error)
    } finally {
      setLoading(false)
    }
  }

  return (
    <main className="p-4">
      <h1 className="text-2xl font-bold mb-4">Add New Customer</h1>
      <form onSubmit={handleSubmit} className="space-y-4 max-w-md">
        <div>
          <Label htmlFor="name">Name</Label>
          <Input id="name" value={name} onChange={(e) => setName(e.target.value)} required />
        </div>
        <div>
          <Label htmlFor="cpf">CPF</Label>
          <Input
            id="cpf"
            value={cpf}
            onChange={(e) => {
              const value = e.target.value.replace(/\D/g, '');
              const formattedValue = value
                .replace(/(\d{3})(\d)/, '$1.$2')
                .replace(/(\d{3})(\d)/, '$1.$2')
                .replace(/(\d{3})(\d{1,2})/, '$1-$2')
                .replace(/(-\d{2})\d+?$/, '$1');
              setCpf(formattedValue);
            }}
            placeholder="000.000.000-00"
            maxLength={14}
            required
          />
        </div>
        <div>
          <Label htmlFor="gender">Gender</Label>
          <Select onValueChange={(value) => setGender(value)}>
            <SelectTrigger id="gender">
              <SelectValue placeholder="Select Gender" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="M">Male</SelectItem>
              <SelectItem value="F">Female</SelectItem>
            </SelectContent>
          </Select>
        </div>
        <div>
          <Label htmlFor="customerType">Customer Type</Label>
          <Select onValueChange={(value) => setCustomerTypeId(Number(value))}>
            <SelectTrigger id="customerType">
              <SelectValue placeholder="Select Customer Type" />
            </SelectTrigger>
            <SelectContent>
              {customerTypes.map((type) => (
                <SelectItem key={type.id} value={type.id.toString()}>
                  {type.description}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
        <div>
          <Label htmlFor="customerStatus">Customer Status</Label>
          <Select onValueChange={(value) => setCustomerStatusId(Number(value))}>
            <SelectTrigger id="customerStatus">
              <SelectValue placeholder="Select Customer Status" />
            </SelectTrigger>
            <SelectContent>
              {customerStatuses.map((status) => (
                <SelectItem key={status.id} value={status.id.toString()}>
                  {status.description}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
        <Button type="submit" disabled={loading}>
          {loading ? "Saving..." : "Save"}
        </Button>
      </form>
    </main>
  )
}
