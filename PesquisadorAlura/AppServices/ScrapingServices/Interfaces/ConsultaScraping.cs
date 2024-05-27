using AppServices.DTO;
using AppServices.ScrapingServices.Implementation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace AppServices.ScrapingServices.Interfaces
{
    public class ConsultaScraping : IConsultaScraping
    {
        public List<ResultadoConsultaDTO> Curso(string textoConsulta)
        {
            List<ResultadoConsultaDTO> resultado = new List<ResultadoConsultaDTO>();
            string driverPrincipal = "";
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.alura.com.br/");

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    ConsultarTesto(driver, textoConsulta);


                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    try
                    {
                        IWebElement coursesList = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("paginacao-pagina")));

                    }
                    catch 
                    {
                        ResultadoConsultaDTO dto = new ResultadoConsultaDTO();
                        dto.Descricao = "Resultado não encontrado";
                        dto.Titulo = "";
                        dto.Professores = new List<string>();
                        resultado.Add(dto);
                        return resultado;
                    }
                    driverPrincipal = driver.CurrentWindowHandle;
                    int numeroElementos = driver.FindElements(By.XPath("//ul[@class='paginacao-pagina']//li//a")).Count;
                    for (int i = 1; i <= numeroElementos; i++)
                    {
                        IWebElement item;
                        try
                        {
                            item = driver.FindElement(By.XPath($"//ul[@class='paginacao-pagina']//li[{i}]//a"));
                            bool isCurso = driver.FindElement(By.XPath($"//ul[@class='paginacao-pagina']//li[{i}]")).Text.Contains("Curso");

                            resultado.Add(isCurso ? GetInfoCurso(item, driver, wait) : GetInfoFormacao(item, driver, wait));
                            driver.SwitchTo().Window(driverPrincipal);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("paginacao-pagina")));

                        }
                        catch
                        {
                            ResultadoConsultaDTO dto = new ResultadoConsultaDTO();
                            dto.Descricao = "Erro na obtencao desse resultado";
                            dto.Titulo = "";
                            dto.Professores = new List<string>();
                            resultado.Add(dto);

                            driver.SwitchTo().Window(driverPrincipal);
                            driver.Navigate().Back();
                            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("paginacao-pagina")));
                        }
                    }

                    return resultado;

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    // Fecha o navegador
                    driver.Quit();
                }
            }
        }
        private ResultadoConsultaDTO GetInfoFormacao(IWebElement aElemnt, IWebDriver driver, WebDriverWait wait)
        {
            string horasClass = "formacao__info-destaque";
            string tituloClass = "formacao-headline-titulo";
            string descricaoClass = "formacao-descricao-texto";
            string professoresListaClass = "formacao-instrutores-lista";
            ResultadoConsultaDTO result = new ResultadoConsultaDTO();

            aElemnt.Click();
            IWebElement elementoHoras = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(horasClass)));
            IWebElement elementoTitulo = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(tituloClass)));
            IWebElement elementoDescricao = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(descricaoClass)));
            IWebElement elementoProfessores = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(professoresListaClass)));

            result.CargaHoraria = int.Parse(elementoHoras?.Text.Replace("h", string.Empty));
            result.Titulo = elementoTitulo?.Text;
            result.Descricao = elementoDescricao?.Text;
            result.Professores = elementoProfessores.FindElements(By.XPath("//ul[@class='formacao-instrutores-lista']//li[@class='formacao-instrutores-instrutor --hidden-tablet']//div//h3")).Select(e => e?.Text).ToList();

            driver.Navigate().Back();

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("paginacao-pagina")));
            return result;
        }
        private ResultadoConsultaDTO GetInfoCurso(IWebElement aElemnt, IWebDriver driver, WebDriverWait wait)
        {
            string horasClass = "courseInfo-card-wrapper-infos";
            string tituloClass = "curso-banner-course-title";
            string descricaoClass = "course-list";
            string professorClass = "instructor-title--name";
            ResultadoConsultaDTO result = new ResultadoConsultaDTO();

            aElemnt.Click();
            IWebElement elementoHoras = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(horasClass)));
            IWebElement elementoTitulo = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(tituloClass)));
            IWebElement elementoDescricao = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(descricaoClass)));
            IWebElement elementoProfessores = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(professorClass)));

            result.CargaHoraria = int.Parse(elementoHoras?.Text.Replace("h", string.Empty));
            result.Titulo = elementoTitulo?.Text;
            result.Descricao = elementoDescricao?.Text;
            result.Professores = new List<string>() { elementoProfessores.FindElement(By.XPath("//section[@id='section-icon']//h3[@class='instructor-title--name']")).Text };

            driver.Navigate().Back();

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("paginacao-pagina")));
            return result;
        }
        public void ConsultarTesto(IWebDriver driver, string textoConsulta)
        {
            driver.FindElement(By.Id("header-barraBusca-form-campoBusca")).SendKeys(textoConsulta);
            driver.FindElement(By.XPath("//input[@id='header-barraBusca-form-campoBusca']/following::button[1]")).Click();
        }
    }
}