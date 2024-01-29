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

# Creating an API
Azure Static Web Apps globally distributes your web app's static assets and hosts your API in Azure Functions. Azure Functions serves your route endpoints, doesn't require a full back-end server to configure or maintain, and provides automatic scaling out and scaling in based on demand.Azure Static Web Apps generates a unique URL for your site, which you can find on the Overview tab in the portal. The API is available through this same URL by appending /api to the URL.

<table>
 <tr>
  <th>Methods
  <th>Route endpoints
  <th>Full API endpoint
 <tr>
 	<td>GET
 	<td>products
 	<td>api/products
 <tr>
  <td>POST
  <td>products
  <td>api/products
 <tr>
  <td>PUT
  <td>products/:id
  <td>api/products/:id
 <tr>
  <td>DELETE
  <td>products/:id
  <td>api/products/:id

- Notice that your HTTP GET requests route to api/products. The api prefix is reserved for your API endpoints in the app. You can define any other routes to fit the needs of your site, but api always points to the Azure Functions app.

## Preview changes to your web app
Before making changes to an app, it's good practice to create a new branch for the changes. You're making several changes when you complete the API for your app, so you create a branch for these changes.

After you make the changes, you want to see them running before deciding to merge the changes. Once you create a pull request from your new branch to the main branch, the GitHub Action builds your app and API, and deploys them both to a preview URL. This preview URL allows you to leave your web app running with Azure Static Web Apps, but also view a second URL with the results from your pull request.

## Configure communication between your web app and API
When you run your API locally, it runs on port 7071 by default. Your web app runs on a different local port. When your web app tries to make an HTTP request from its port to your API's port 7071, the action is known as Cross-Origin Resource Sharing (CORS). Your browser prevents the HTTP request from completing unless the API server allows the request to proceed.

When you publish to Azure Static Web Apps, you don't have to worry about CORS. Azure Static Web Apps automatically configures your app so it can communicate with your API on Azure using a reverse proxy. A reverse proxy is what allows your web app and API to appear to come from the same web domain. So you only have to set up CORS when you run locally.

## Configure Cross-Origin Resource Sharing (CORS) locally
You don't have to worry about Cross-Origin Resource Sharing (CORS) when you publish to Azure Static Web Apps. Azure Static Web Apps automatically configures your app so it can communicate with your API on Azure using a reverse proxy. But when running locally, you need to configure CORS to allow your web app and API to communicate.

# launchSettings.json
{
    "profiles": {
        "Api": {
            "commandName": "Project",
            "commandLineArgs": "start --cors *"
        }
    }
}
	
### Note

<i>This file is used to control how Visual Studio will launch the Azure Functions tooling. If you want to use the Azure Functions command line tool, you will also need a local.settings.json file described in the Azure Functions Core Tools docs. The local.settings.json file is listed in the .gitignore file, which prevents this file from being pushed to GitHub. This is because you could store secrets in this file that you would not want in GitHub. Also, this is why you had to create the file when you created your repo from the template.


## Run the API and web app

. In Visual Studio, right-click the ShoppingList solution.
. Select Set Startup Projects.
. Select the Multiple startup projects option.
. Set Api and Client to have Start as their Action, and then select Ok.
. Launch the debugger.
		
		