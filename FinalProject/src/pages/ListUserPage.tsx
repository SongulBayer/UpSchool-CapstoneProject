import React, { useEffect, useState } from 'react'
import { UserGetAllDto } from '../types/UserTypes';
import api from '../utils/axiosInstance';
import { Table } from 'semantic-ui-react';

function ListUserPage() {
    const [users, setUsers] = useState<UserGetAllDto[]>([]);
  
    
    
    useEffect(() => {
      const fetchOrderProducts = async () => {
        try {

          const response = await api.post<UserGetAllDto[]>("/Users/GetAll")
          setUsers(response.data);
        } catch (error) {
          console.error("Error fetching order products:", error);
        }
      };
  
      fetchOrderProducts();
    }, []);
  
    // Diğer JSX içeriğini ve tabloyu aşağıdaki gibi oluşturun:
    return (
      <div style={{ marginTop: '100px' }}>
        <Table celled>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell>First Name</Table.HeaderCell>
              <Table.HeaderCell>Last Name</Table.HeaderCell>
              <Table.HeaderCell>Email</Table.HeaderCell>
  
              
              
              {/* Diğer ürün bilgilerini buraya ekleyin */}
            </Table.Row>
          </Table.Header>
          <Table.Body>
            {users.map((user) => (
              <Table.Row key={user.id}>
                <Table.Cell>{user.firstName}</Table.Cell>
                <Table.Cell>{user.lastName}</Table.Cell>
                <Table.Cell>{user.email}</Table.Cell>
  
                {/* Diğer ürün bilgilerini buraya ekleyin */}
              </Table.Row>
            ))}
          </Table.Body>
        </Table>
      </div>
    );
}

export default ListUserPage;
