# Configure a Fallback Route
<b>Problem:</b> There's a client-side route /products in your front-end application that displays a list of products for your shopping list. When you go to /products in your app by selecting the Products link, your browser's address bar confirms that you're at /products. When you refresh the browser while on this page, you want the app to refresh and display the products once again. However, without a fallback route, you see a 404 error stating the page can't be found.

## Configuration

Azure Static Web Apps supports custom routing rules defined in an optional <code>staticwebapp.config.json</code> file located in the app's source folder (wwwroot within the Client project.). You can define a navigation fallback route in the navigationFallback object. A common fallback route configuration looks like this example.

### Fallback Route
JSON
{
  "navigationFallback": {
    "rewrite": "/index.html",
    "exclude": ["/_framework/*", "/css/*"]
  }
}
<table>
 <tr>
  <th>Setting</th>
  <th>Value</th>
  <th>Description</th>
 </tr>
 <tr>
  <td>rewrite</td>
  <td>/index.html</td>
  <td>The file to serve when a route doesn't match any other files.</td>
 </tr>
 <tr>
  <td>exclude</td>
  <td>["/_framework/*", "/css/*"]</td>
  <td>Path(s) to ignore from fallback routing.</td>
 </tr>
</table>



		
		