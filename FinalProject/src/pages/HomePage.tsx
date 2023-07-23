import React from 'react'

 function HomePage() {
  return (
    <div style={{ marginTop: "100px", textAlign: "center" }}>
    <h1 style={{ fontSize: "36px", fontWeight: "bold" ,color:"	#052e53"}}>Up School Final Project</h1>
   
    <p style={{ fontSize: "30px" ,fontWeight:"bold" ,color:"#0f477a"}}>
    <i  className="rocket icon"></i> The technologies used in this project are:
    </p>
    <ul style={{ fontSize: "19px", listStyleType: "none", padding: "0",color:"#1d609f" }}>
      <li>Asp .Net 7 ile Entity Framework Core</li>
      <li>Signal R</li>
      <li>Background Worker</li>
      <li>SMTP</li>
      <li>Postgre SQL</li>
      <li>CodeFirst Method</li>
      <li>Clean Architecture</li>
      <li>TypeScript</li>
      <li>Semantic UI</li>

      {/* Diğer teknolojileri buraya ekleyebilirsiniz */}
    </ul>

    <p style={{ fontSize: "30px" ,fontWeight:"bold" ,color:"#0f477a"}}>
    <i  className="cogs icon"></i> The project consists of 6 layers.:
    </p>
    <ul style={{ fontSize: "19px", listStyleType: "none", padding: "0",color:"#1d609f" }}>
      <li>Application Layer</li>
      <li>CrawlerService Layer</li>
      <li>Domain Layer</li>
      <li>Domain Layer</li>
      <li>Wasm Layer</li>
      <li>Web Api Layer</li>

    </ul>
    <p style={{ fontSize: "30px" ,fontWeight:"bold" ,color:"#0f477a"}}>
    <i  className="pencil icon"></i> Notes:
    
    </p>
    <ul style={{ fontSize: "19px", listStyleType: "none", padding: "0",color:"#1d609f" }}>
      <li>PostgreSql is used as the database in the project.</li>
      <li>Emails are sent every time a NewAccount is added.</li>
      </ul>
  </div>
  )
}
export default HomePage
