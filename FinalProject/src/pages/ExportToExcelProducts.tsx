// import React, { useEffect, useState } from 'react';
// import { Button, Table } from 'semantic-ui-react';
// import api from '../utils/axiosInstance';
// import { ProductGetAllDto, ProductGetAllQuery } from '../types/ProductTypes';
// import { useParams } from 'react-router-dom';

// function ExportToExcelProducts() {
//   const { orderId } = useParams();
//   const [orderProducts, setOrderProducts] = useState<ProductGetAllDto[]>([]);

//   useEffect(() => {
//     const fetchOrderProducts = async () => {
//       try {
//         const productQuery: ProductGetAllQuery = {
//           orderId: orderId,
//         };

//         const response = await api.post<ProductGetAllDto[]>('/Products/GetAll', productQuery);
//         setOrderProducts(response.data);
//       } catch (error) {
//         console.error('Error fetching order products:', error);
//       }
//     };

//     fetchOrderProducts();
//   }, [orderId]);

//   // Excel dosya için stil tanımları
//   const excelStyles = {
//     headerStyle: {
//       fill: {
//         fgColor: { rgb: 'CCCCCC' },
//       },
//       font: {
//         color: { rgb: '000000' },
//         sz: 14,
//         bold: true,
//       },
//     },
//     contentStyle: {
//       font: {
//         color: { rgb: '000000' },
//         sz: 12,
//       },
//     },
//   };

//   // Diğer JSX içeriğini ve tabloyu aşağıdaki gibi oluşturun:
//   return (
//     <div style={{ marginTop: '100px' }}>
//       <ExcelFile element={<Button>Export to Excel</Button>}>
//         <ExcelSheet data={orderProducts} name="Order Products">
//           <ExcelColumn label="Name" value="name" />
//           <ExcelColumn label="Picture" value="picture" />
//           <ExcelColumn label="Is On Sale?" value={(col:boolean) => (col.isOnSale ? 'Yes' : 'No')} />
//           <ExcelColumn label="Price" value="price" />
//           <ExcelColumn label="Sale Price" value="salePrice" />
//         </ExcelSheet>
//       </ExcelFile>
//       <Table celled>
//         <Table.Header>
//           <Table.Row>
//             <Table.HeaderCell>Name</Table.HeaderCell>
//             <Table.HeaderCell>Picture</Table.HeaderCell>
//             <Table.HeaderCell>Is On Sale?</Table.HeaderCell>
//             <Table.HeaderCell>Price</Table.HeaderCell>
//             <Table.HeaderCell>Sale Price</Table.HeaderCell>
//           </Table.Row>
//         </Table.Header>
//         <Table.Body>
//           {orderProducts.map((product) => (
//             <Table.Row key={product.id}>
//               <Table.Cell>{product.name}</Table.Cell>
//               <Table.Cell>{product.picture}</Table.Cell>
//               <Table.Cell>{product.isOnSale ? 'Yes' : 'No'}</Table.Cell>
//               <Table.Cell>{product.price}</Table.Cell>
//               <Table.Cell>{product.salePrice}</Table.Cell>
//             </Table.Row>
//           ))}
//         </Table.Body>
//       </Table>
//     </div>
//   );
// }

// export default ExportToExcelProducts;
