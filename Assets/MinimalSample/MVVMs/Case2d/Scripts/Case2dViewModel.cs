using Unity.Properties;
    
public class Case2dViewModel
{
    // Dependencies
    private readonly ICurrentCaseService m_CurrentCaseService;
    // Properties
    [CreateProperty]
    public string CaseName { get; set; } = "Unknown";
    
    // Constructors
    public Case2dViewModel(ICurrentCaseService currentCaseService)
    {
        m_CurrentCaseService = currentCaseService;
        Setup();
    }

    public void Setup()
    {
        CaseName = m_CurrentCaseService.CurrentCase;
    }
}