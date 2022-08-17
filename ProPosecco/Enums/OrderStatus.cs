using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Oczekuje na płatność")] Waiting = 0,
        [Display(Name = "Przyjęte do realizacji")] InProgress,
        [Display(Name = "Zrealizowane")] Completed,
        [Display(Name = "Anulowane")] Cancelled
    }
}
