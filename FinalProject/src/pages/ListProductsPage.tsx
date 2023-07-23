import React, { useEffect, useState } from 'react'
import { Button, Icon, Table } from 'semantic-ui-react';
import api from '../utils/axiosInstance';
import { ProductGetAllDto, ProductGetAllQuery, ProductRemoveCommand } from '../types/ProductTypes';
import { useParams } from 'react-router-dom';

function ListProductsPage() {

  const { orderId } = useParams();
  const [orderProducts, setOrderProducts] = useState<ProductGetAllDto[]>([]);



  useEffect(() => {
    const fetchOrderProducts = async () => {
      try {

        const productQuery: ProductGetAllQuery = {
          orderId: orderId,
        };
        console.log(productQuery);
        console.log(orderId);

        const response = await api.post<ProductGetAllDto[]>("/Products/GetAll", productQuery)
        setOrderProducts(response.data);
      } catch (error) {
        console.error("Error fetching order products:", error);
      }
    };

    fetchOrderProducts();
  }, [orderId]);

  async function removeProduct(productId : string){
    try {

      const productCommand: ProductRemoveCommand = {
        id: productId,
      };

      const response = await api.post("/Products/Delete", productCommand)
      setOrderProducts(response.data);
      window.location.reload();
    } catch (error) {
      console.error("Error fetching order products:", error);
    }
  }


  // Diğer JSX içeriğini ve tabloyu aşağıdaki gibi oluşturun:
  return (
    <div style={{ marginTop: '100px' }}>
      <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Name</Table.HeaderCell>
            <Table.HeaderCell>Picture</Table.HeaderCell>
            <Table.HeaderCell>Is On Sale?</Table.HeaderCell>
            <Table.HeaderCell>Price</Table.HeaderCell>
            <Table.HeaderCell>Sale Price</Table.HeaderCell>
            <Table.HeaderCell collspan={2}>Delete</Table.HeaderCell>




            {/* Diğer ürün bilgilerini buraya ekleyin */}
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {orderProducts.map((product) => (
            <Table.Row key={product.id}>
              <Table.Cell>{product.name}</Table.Cell>
              <Table.Cell>{product.picture}</Table.Cell>
              <Table.Cell>{product.isOnSale ? "Yes" : "No"}</Table.Cell>
              <Table.Cell>{product.price}</Table.Cell>
              <Table.Cell>{product.salePrice}</Table.Cell>
              <Table.Cell>
                {/* Detayları göster düğmesini ekleyin ve tıklamada OrderProductsPage component'ına order ID'sini geçirin */}
                <Button color='red' onClick={() => removeProduct(product.id)}>Delete
                <Icon name="trash" />
                </Button>
              </Table.Cell>
              {/* Diğer ürün bilgilerini buraya ekleyin */}
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </div>
  );
}

export default ListProductsPage;
